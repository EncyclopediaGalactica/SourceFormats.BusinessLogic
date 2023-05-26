namespace EncyclopediaGalactica.SourceFormats.SourceFormatsRepository.Interfaces;

using Entities;
using Exceptions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Utils.GuardsService.Exceptions;

/// <summary>
///     SourceFormatRepository interface for managing stored data in the database.
/// </summary>
public interface ISourceFormatNodeRepository
{
    /// <summary>
    ///     Adds a new entity to the database.
    /// </summary>
    /// <param name="node">Object with details of the new entity.</param>
    /// <param name="cancellationToken">
    ///     <see cref="CancellationToken">Cancellation token.</see>
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///     When input is null.
    /// </exception>
    /// <exception cref="ValidationException">
    ///     When input is invalid.
    /// </exception>
    /// <exception cref="DbUpdateException">
    ///     Error happened while saving into the database
    /// </exception>
    /// <exception cref="DbUpdateConcurrencyException">
    ///     Concurrency violation happened while saving into the database.
    /// </exception>
    /// <exception cref="OperationCanceledException">
    ///     When operation is cancelled using <see cref="CancellationToken" />
    /// </exception>
    /// <returns>
    ///     Returns <see cref="Task" /> which includes the new created <see cref="SourceFormatNode" />
    ///     entity.
    /// </returns>
    Task<SourceFormatNode> AddAsync(SourceFormatNode node, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Adds a <see cref="SourceFormatNode" /> to another <see cref="SourceFormatNode" /> as child node.
    /// </summary>
    /// <param name="childId">Id of the entity which will be added as child.</param>
    /// <param name="parentId">Id of the parent entity</param>
    /// <param name="rootNodeId">Id of the root node</param>
    /// <param name="cancellationToken">
    ///     <see cref="CancellationToken" />
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///     Input is null
    /// </exception>
    /// <exception cref="InvalidOperationException">
    ///     Sequence does not contain any element
    /// </exception>
    /// <exception cref="GuardsServiceValueShouldNoBeNullException">
    ///     Provided value is null
    /// </exception>
    /// <exception cref="GuardsServiceValueShouldNotBeEqualToException">
    ///     Provided value equals to an undesired value
    /// </exception>
    /// <exception cref="OperationCanceledException">
    ///     Operation is cancelled by a <see cref="CancellationToken" />
    /// </exception>
    /// <returns>
    ///     Returns <see cref="Task" /> representing asynchronous operation which includes
    ///     the child object.
    /// </returns>
    Task<SourceFormatNode> AddChildNodeAsync(
        long childId,
        long parentId,
        long rootNodeId,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Updates the defined <see cref="SourceFormatNode" /> entity by the provided object property values.
    /// </summary>
    /// <param name="node">Object containing the new values.</param>
    /// <param name="cancellationToken">
    ///     <see cref="CancellationToken" />
    /// </param>
    /// <exception cref="SourceFormatNodeRepositoryException">
    ///     In case of any error and its enclosed exceptions provide additional details
    ///     about the error.
    /// </exception>
    /// <returns>
    ///     Returns <see cref="Task" /> representing asynchronous operation which includes the updated
    ///     <see cref="SourceFormatNode" />
    ///     entity.
    /// </returns>
    Task<SourceFormatNode> UpdateAsync(SourceFormatNode node, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Deletes the defined <see cref="SourceFormatNode" /> entity.
    /// </summary>
    /// <param name="id">Identifier of the entity will be deleted</param>
    /// <param name="cancellationToken">
    ///     <see cref="CancellationToken" />
    /// </param>
    /// <exception cref="InvalidOperationException">
    ///     When no such entity
    /// </exception>
    /// <exception cref="ArgumentNullException">
    ///     When null input provided.
    /// </exception>
    /// <exception cref="GuardsServiceValueShouldNotBeEqualToException">
    ///     When the provided Id value is 0
    /// </exception>
    /// <returns>
    ///     Returns <see cref="Task" /> representing asynchronous operation.
    /// </returns>
    Task DeleteAsync(long id, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Returns all <see cref="SourceFormatNode" /> entities as <see cref="List{T}" />.
    /// </summary>
    /// <param name="cancellationToken">
    ///     <see cref="CancellationToken" />
    /// </param>
    /// <exception cref="GuardsServiceValueShouldNotBeEqualToException">
    ///     When provided value equals to a value.
    /// </exception>
    /// <exception cref="GuardsServiceValueShouldNoBeNullException">
    ///     When provided value is null.
    /// </exception>
    /// <exception cref="OperationCanceledException">
    ///     When operation is cancelled by a <see cref="CancellationToken" />
    /// </exception>
    /// <exception cref="DbUpdateException">
    ///     When data cannot be persisted into database for some reason.
    /// </exception>
    /// <exception cref="DbUpdateConcurrencyException">
    ///     Persisting data into database is not possibly due to concurrency issues.
    /// </exception>
    /// <returns>
    ///     Returns <see cref="Task" /> representing asynchronous operation which includes the result.
    /// </returns>
    Task<List<SourceFormatNode>> GetAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    ///     Returns the identified <see cref="SourceFormatNode" /> entity with its children entities.
    /// </summary>
    /// <param name="id">Identifier of the desired entity.</param>
    /// <param name="cancellationToken">
    ///     <see cref="CancellationToken" />
    /// </param>
    /// <exception cref="SourceFormatNodeRepositoryException">
    ///     In case of any error and its inner exceptions provide
    ///     further details about the error.
    /// </exception>
    /// <returns>
    ///     Returns <see cref="Task" /> representing asynchronous operation which encloses the result.
    /// </returns>
    Task<SourceFormatNode> GetByIdWithChildrenAsync(long id, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Returns the identified <see cref="SourceFormatNode" /> entity without its related entities.
    /// </summary>
    /// <param name="id">Identifier of the desired entity.</param>
    /// <exception cref="SourceFormatNodeRepositoryException">
    ///     In case of any error and its inner exceptions provide
    ///     further details on the error occured.
    /// </exception>
    /// <returns>
    ///     Returns <see cref="Task" /> representing asynchronous operation which encloses the result.
    /// </returns>
    Task<SourceFormatNode> GetByIdAsync(long id);

    /// <summary>
    ///     Returns a flatten (partial) tree which starting point is the identified <see cref="SourceFormatNode" />
    ///     entity. The flatten tree means a list of items belong to the root <see cref="SourceFormatNode" />.
    ///     Navigation property of <see cref="SourceFormatNode" /> considering which entities are child of an entity
    ///     are populated.
    /// </summary>
    /// <param name="id">Identifier of the desired entity</param>
    /// <param name="cancellationToken">
    ///     <see cref="CancellationToken" />
    /// </param>
    /// <exception cref="SourceFormatNodeRepositoryException">
    ///     In case of any error and its inner exceptions provide
    ///     additional details on the error occured.
    /// </exception>
    /// <returns>
    ///     Returns <see cref="Task" /> representing asynchronous operation which includes the result.
    /// </returns>
    Task<List<SourceFormatNode>> GetByIdWithFlatTreeAsync(long id, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Returns with given <see cref="SourceFormatNode" /> where its root node is also attached.
    ///     If the given node does not have a root node yet, the RootNode property is null.
    /// </summary>
    /// <param name="id">Identifier of the <see cref="SourceFormatNode" /></param>
    /// <param name="cancellationToken">
    ///     <see cref="CancellationToken" />
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///     Input parameter is null
    /// </exception>
    /// <exception cref="InvalidOperationException">
    ///     The result sequence does not contain any element.
    /// </exception>
    /// <exception cref="GuardsServiceValueShouldNotBeEqualToException">
    ///     The provided id value is zero.
    /// </exception>
    /// <returns>
    ///     Returns <see cref="Task{TResult}" /> representing result of asynchronous operation including the result.
    /// </returns>
    Task<SourceFormatNode> GetByIdWithRootNodeAsync(long id, CancellationToken cancellationToken = default);
}