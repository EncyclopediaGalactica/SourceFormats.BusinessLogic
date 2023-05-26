namespace EncyclopediaGalactica.SourceFormats.Sdk.Interfaces;

using Dtos;
using Entities;
using Models.Document;

/// <summary>
///     The IDocumentsSdk interface
///     <remarks>
///         It provides methods to access the <see cref="Document" /> entities in the system
///         using Http protocol.
///     </remarks>
/// </summary>
public interface IDocumentsSdk
{
    /// <summary>
    ///     Adds a new <see cref="Document" /> to the system where the properties of the new entity will be
    ///     based on the provided <see cref="DocumentDto" /> object's properties.
    /// </summary>
    /// <param name="model">the provided dto object</param>
    /// <param name="cancellationToken">
    ///     <see cref="CancellationToken" />
    /// </param>
    /// <returns>
    ///     Returns <see cref="Task{TResult}" /> representing result of an asynchronous operation.
    ///     The result is <see cref="DocumentAddResponseModel" /> containing the actual result and some details
    ///     about the operation.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     If the input is null or the model.Payload is null
    /// </exception>
    Task<DocumentAddResponseModel> AddAsync(
        DocumentAddRequestModel model,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Returns the data of the designated <see cref="Document" /> entity mapped to a <see cref="DocumentDto" />
    ///     object.
    ///     <remarks>
    ///         If there is no entity with the Id provided then it returns an error message.
    ///     </remarks>
    /// </summary>
    /// <param name="requestModel">the model including the Id designating the requested entity</param>
    /// <param name="cancellationToken">
    ///     <see cref="CancellationToken" />
    /// </param>
    /// <returns>
    ///     Returns <see cref="Task{TResult}" /> representing result of an asynchronous operation.
    ///     The result is <see cref="DocumentGetByIdResponseModel" /> containing the actual result and some details
    ///     about the operation.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     If the input is null or the model.Payload is null
    /// </exception>
    Task<DocumentGetByIdResponseModel> GetByIdAsync(
        DocumentGetByIdRequestModel requestModel,
        CancellationToken cancellationToken = default);
}