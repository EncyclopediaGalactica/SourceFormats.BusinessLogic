namespace EncyclopediaGalactica.Services.Document.Scenario.Interfaces.StructureNode;

using Contracts.Output;
using Exceptions;

/// <summary>
///     Get root <see cref="StructureNode" /> by <see cref="Document.Id" /> scenario.
///     <remarks>
///         This scenario is used in cases where a <see cref="StructureNode" /> is attached to <see cref="Document" />
///         entities in Graphql output.
///     </remarks>
/// </summary>
public interface IGetRootStructureNodeByDocumentIdScenario
{
    /// <summary>
    ///     Returns the <see cref="StructureNodeResult" /> which is the root node of the designated <see cref="Document" />
    ///     entity.
    /// </summary>
    /// <remarks>
    ///     By rule there can be only 1 root <see cref="StructureNode" /> to a <see cref="Document" /> entity. The method does
    ///     internal check if there are multiple root nodes of a <see cref="Document" />. If so, it throws an exception.
    /// </remarks>
    /// <param name="documentId">The <see cref="Document" /> Id field.</param>
    /// <returns>The root node of the designated <see cref="Document" /> entity.</returns>
    /// <exception cref="InvalidArgumentScenarioException">
    ///     When invalid arguments were passed to the scenario.
    /// </exception>
    /// <exception cref="NoSuchItemScenarioException">
    ///     When there is no such item in the system.
    /// </exception>
    /// <exception cref="OperationCancelledScenarioException">
    ///     When the scenario execution is been cancelled by <see cref="CancellationToken" />.
    /// </exception>
    /// <exception cref="DataCohesionScenarioException">
    ///     When the code executed by the scenario cause data cohesion issues.
    /// </exception>
    /// <exception cref="UnknownErrorScenarioException">
    ///     Any further exception happen in the scenario.
    /// </exception>
    Task<StructureNodeResult> GetRootNodeByDocumentIdAsync(long documentId);
}