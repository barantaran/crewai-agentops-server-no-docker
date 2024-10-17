using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using AgentopsServer.Models;
using Microsoft.EntityFrameworkCore;

namespace AgentopsServer.Controllers
{

    public class AgentsControllerTests
    {
        private readonly Mock<ILogger<AgentSessionController>> _mockLogger;
        private readonly DbContextOptions<AgentServerDbContext> _dbContextOptions;

        public AgentsControllerTests()
        {
            // Setup in-memory database options
            _dbContextOptions = new DbContextOptionsBuilder<AgentServerDbContext>()
                .UseInMemoryDatabase(databaseName: "TestAgentDb")
                .Options;

            // Mock the ILogger
            _mockLogger = new Mock<ILogger<AgentSessionController>>();
        }

        private void ClearDatabase(AgentServerDbContext context)
        {
            context.Agents.RemoveRange(context.Agents);
            context.SaveChanges();
        }

        [Fact]
        public async Task GetAgents_ReturnsAllAgents_WhenAgentsExist()
        {
            // Arrange
            using (var context = new AgentServerDbContext(_dbContextOptions))
            {
                ClearDatabase(context);
                context.Agents.AddRange(new List<Agent>
            {
                new Agent { AgentId = 1, Name = "Agent 1" },
                new Agent { AgentId = 2, Name = "Agent 2" }
            });
                context.SaveChanges();

                var controller = new AgentsController(_mockLogger.Object, context);

                // Act
                var result = await controller.GetAgents();

                // Assert
                var actionResult = Assert.IsType<ActionResult<IEnumerable<Agent>>>(result);
                var returnValue = Assert.IsType<List<Agent>>(actionResult.Value);
                Assert.Equal(2, returnValue.Count);
            }
        }

        [Fact]
        public async Task GetAgent_ReturnsAgent_WhenAgentExists()
        {
            // Arrange
            using (var context = new AgentServerDbContext(_dbContextOptions))
            {
                context.Agents.Add(new Agent { AgentId = 1, Name = "Agent 1" });
                context.SaveChanges();

                var controller = new AgentsController(_mockLogger.Object, context);

                // Act
                var result = await controller.GetAgent(1);

                // Assert
                var actionResult = Assert.IsType<ActionResult<Agent>>(result);
                var returnValue = Assert.IsType<Agent>(actionResult.Value);
                Assert.Equal("Agent 1", returnValue.Name);
            }
        }

        [Fact]
        public async Task GetAgent_ReturnsNotFound_WhenAgentDoesNotExist()
        {
            // Arrange
            using (var context = new AgentServerDbContext(_dbContextOptions))
            {
                var controller = new AgentsController(_mockLogger.Object, context);

                // Act
                var result = await controller.GetAgent(999);

                // Assert
                Assert.IsType<NotFoundResult>(result.Result);
            }
        }

        [Fact]
        public async Task PostAgent_CreatesAgent_WhenAgentIsValid()
        {
            // Arrange
            using (var context = new AgentServerDbContext(_dbContextOptions))
            {
                var controller = new AgentsController(_mockLogger.Object, context);
                var newAgent = new Agent { Name = "New Agent" };

                // Act
                var result = await controller.PostAgent(newAgent);

                // Assert
                var createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);
                var returnValue = Assert.IsType<Agent>(createdResult.Value);
                Assert.Equal("New Agent", returnValue.Name);
                Assert.NotEqual(0, returnValue.AgentId); // Id should be generated
            }
        }
    }
}
