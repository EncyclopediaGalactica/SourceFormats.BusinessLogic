namespace EncyclopediaGalactica.SourceFormats.SourceFormatsService.Interfaces.Document;

using Dtos;
using Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Utils.GuardsService.Exceptions;

/// <summary>
///     IDocument Service interface.
///     <remarks>
///         The service provides Api methods to access <see cref="Document" /> objects stored in the system.
///     </remarks>
/// </summary>
public interface IDocumentService
{
    /// <summary>
    ///     Adds a <see cref="Document" /> object to the system with the values represented by the provided
    ///     <see cref="DocumentDto" />.
    /// </summary>
    /// <param name="dto">The input object</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>
    ///     Returns a <see cref="Task{TResult}" /> object representing the result of an asynchronous operation.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     When input is null.
    /// </exception>
    /// <exception cref="ValidationException">When input is invalid</exception>
    /// <exception cref="DbUpdateException">
    ///     When a constraint defined by SQL schema is violated. It is mainly validation
    ///     related problem.
    /// </exception>
    /// <exception cref="OperationCanceledException">
    ///     When the operation is cancelled by a <see cref="CancellationToken" />
    /// </exception>
    Task<DocumentDto> AddAsync(DocumentDto dto, CancellationToken cancellationToken = default);

    Task<List<Document>> GetAll(CancellationToken cancellationToken = default);

    /// <summary>
    ///     Returns with the indicated <see cref="Document" />'s values mapped to a <see cref="DocumentDto" /> object.
    /// </summary>
    /// <param name="id">The id value</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>
    ///     Returns <see cref="Task{TResult}" /> representing result of an asynchronous operation. It includes the
    ///     <see cref="DocumentDto" /> result.
    /// </returns>
    /// <exception cref="ArgumentNullException">When the input is null</exception>
    /// <exception cref="GuardsServiceValueShouldNotBeEqualToException">When the input is invalid</exception>
    /// <exception cref="InvalidOperationException">When there is no such item</exception>
    /// <exception cref="OperationCanceledException">
    ///     When the operation is cancelled by a <see cref="CancellationToken" />.
    /// </exception>
    Task<DocumentDto> GetByIdAsync(long id, CancellationToken cancellationToken = default);
}