/**
 * This file is automatically created by Recurly's OpenAPI generation process
 * and thus any edits you make by hand will be lost. If you wish to make a
 * change to this file, please create a Github issue explaining the changes you
 * need and we will usher them to the appropriate places.
 */
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Recurly.Errors
{


    [ExcludeFromCodeCoverage]
    public class Response : ApiError
    {
        public Response() { }
        public Response(string message) : base(message) { }
        public Response(string message, Exception inner) : base(message, inner) { }
    }

    [ExcludeFromCodeCoverage]
    public class Server : Response
    {
        public Server() { }
        public Server(string message) : base(message) { }
        public Server(string message, Exception inner) : base(message, inner) { }
    }

    [ExcludeFromCodeCoverage]
    public class InternalServer : Server
    {
        public InternalServer() { }
        public InternalServer(string message) : base(message) { }
        public InternalServer(string message, Exception inner) : base(message, inner) { }
    }

    [ExcludeFromCodeCoverage]
    public class ServiceNotAvailable : InternalServer
    {
        public ServiceNotAvailable() { }
        public ServiceNotAvailable(string message) : base(message) { }
        public ServiceNotAvailable(string message, Exception inner) : base(message, inner) { }
    }

    [ExcludeFromCodeCoverage]
    public class BadGateway : Server
    {
        public BadGateway() { }
        public BadGateway(string message) : base(message) { }
        public BadGateway(string message, Exception inner) : base(message, inner) { }
    }

    [ExcludeFromCodeCoverage]
    public class ServiceUnavailable : Server
    {
        public ServiceUnavailable() { }
        public ServiceUnavailable(string message) : base(message) { }
        public ServiceUnavailable(string message, Exception inner) : base(message, inner) { }
    }

    [ExcludeFromCodeCoverage]
    public class Timeout : Server
    {
        public Timeout() { }
        public Timeout(string message) : base(message) { }
        public Timeout(string message, Exception inner) : base(message, inner) { }
    }

    [ExcludeFromCodeCoverage]
    public class Redirection : Response
    {
        public Redirection() { }
        public Redirection(string message) : base(message) { }
        public Redirection(string message, Exception inner) : base(message, inner) { }
    }

    [ExcludeFromCodeCoverage]
    public class NotModified : Response
    {
        public NotModified() { }
        public NotModified(string message) : base(message) { }
        public NotModified(string message, Exception inner) : base(message, inner) { }
    }

    [ExcludeFromCodeCoverage]
    public class Client : ApiError
    {
        public Client() { }
        public Client(string message) : base(message) { }
        public Client(string message, Exception inner) : base(message, inner) { }
    }

    [ExcludeFromCodeCoverage]
    public class BadRequest : Client
    {
        public BadRequest() { }
        public BadRequest(string message) : base(message) { }
        public BadRequest(string message, Exception inner) : base(message, inner) { }
    }

    [ExcludeFromCodeCoverage]
    public class InvalidContentType : BadRequest
    {
        public InvalidContentType() { }
        public InvalidContentType(string message) : base(message) { }
        public InvalidContentType(string message, Exception inner) : base(message, inner) { }
    }

    [ExcludeFromCodeCoverage]
    public class Unauthorized : Client
    {
        public Unauthorized() { }
        public Unauthorized(string message) : base(message) { }
        public Unauthorized(string message, Exception inner) : base(message, inner) { }
    }

    [ExcludeFromCodeCoverage]
    public class PaymentRequired : Client
    {
        public PaymentRequired() { }
        public PaymentRequired(string message) : base(message) { }
        public PaymentRequired(string message, Exception inner) : base(message, inner) { }
    }

    [ExcludeFromCodeCoverage]
    public class Forbidden : Client
    {
        public Forbidden() { }
        public Forbidden(string message) : base(message) { }
        public Forbidden(string message, Exception inner) : base(message, inner) { }
    }

    [ExcludeFromCodeCoverage]
    public class InvalidApiKey : Forbidden
    {
        public InvalidApiKey() { }
        public InvalidApiKey(string message) : base(message) { }
        public InvalidApiKey(string message, Exception inner) : base(message, inner) { }
    }

    [ExcludeFromCodeCoverage]
    public class InvalidPermissions : Forbidden
    {
        public InvalidPermissions() { }
        public InvalidPermissions(string message) : base(message) { }
        public InvalidPermissions(string message, Exception inner) : base(message, inner) { }
    }

    [ExcludeFromCodeCoverage]
    public class NotFound : Client
    {
        public NotFound() { }
        public NotFound(string message) : base(message) { }
        public NotFound(string message, Exception inner) : base(message, inner) { }
    }

    [ExcludeFromCodeCoverage]
    public class NotAcceptable : Client
    {
        public NotAcceptable() { }
        public NotAcceptable(string message) : base(message) { }
        public NotAcceptable(string message, Exception inner) : base(message, inner) { }
    }

    [ExcludeFromCodeCoverage]
    public class UnknownApiVersion : NotAcceptable
    {
        public UnknownApiVersion() { }
        public UnknownApiVersion(string message) : base(message) { }
        public UnknownApiVersion(string message, Exception inner) : base(message, inner) { }
    }

    [ExcludeFromCodeCoverage]
    public class UnavailableInApiVersion : NotAcceptable
    {
        public UnavailableInApiVersion() { }
        public UnavailableInApiVersion(string message) : base(message) { }
        public UnavailableInApiVersion(string message, Exception inner) : base(message, inner) { }
    }

    [ExcludeFromCodeCoverage]
    public class InvalidApiVersion : NotAcceptable
    {
        public InvalidApiVersion() { }
        public InvalidApiVersion(string message) : base(message) { }
        public InvalidApiVersion(string message, Exception inner) : base(message, inner) { }
    }

    [ExcludeFromCodeCoverage]
    public class PreconditionFailed : Client
    {
        public PreconditionFailed() { }
        public PreconditionFailed(string message) : base(message) { }
        public PreconditionFailed(string message, Exception inner) : base(message, inner) { }
    }

    [ExcludeFromCodeCoverage]
    public class UnprocessableEntity : Client
    {
        public UnprocessableEntity() { }
        public UnprocessableEntity(string message) : base(message) { }
        public UnprocessableEntity(string message, Exception inner) : base(message, inner) { }
    }

    [ExcludeFromCodeCoverage]
    public class Validation : UnprocessableEntity
    {
        public Validation() { }
        public Validation(string message) : base(message) { }
        public Validation(string message, Exception inner) : base(message, inner) { }
    }

    [ExcludeFromCodeCoverage]
    public class MissingFeature : UnprocessableEntity
    {
        public MissingFeature() { }
        public MissingFeature(string message) : base(message) { }
        public MissingFeature(string message, Exception inner) : base(message, inner) { }
    }

    [ExcludeFromCodeCoverage]
    public class Transaction : UnprocessableEntity
    {
        public Transaction() { }
        public Transaction(string message) : base(message) { }
        public Transaction(string message, Exception inner) : base(message, inner) { }
    }

    [ExcludeFromCodeCoverage]
    public class SimultaneousRequest : UnprocessableEntity
    {
        public SimultaneousRequest() { }
        public SimultaneousRequest(string message) : base(message) { }
        public SimultaneousRequest(string message, Exception inner) : base(message, inner) { }
    }

    [ExcludeFromCodeCoverage]
    public class ImmutableSubscription : UnprocessableEntity
    {
        public ImmutableSubscription() { }
        public ImmutableSubscription(string message) : base(message) { }
        public ImmutableSubscription(string message, Exception inner) : base(message, inner) { }
    }

    [ExcludeFromCodeCoverage]
    public class InvalidToken : UnprocessableEntity
    {
        public InvalidToken() { }
        public InvalidToken(string message) : base(message) { }
        public InvalidToken(string message, Exception inner) : base(message, inner) { }
    }

    [ExcludeFromCodeCoverage]
    public class TooManyRequests : Client
    {
        public TooManyRequests() { }
        public TooManyRequests(string message) : base(message) { }
        public TooManyRequests(string message, Exception inner) : base(message, inner) { }
    }

    [ExcludeFromCodeCoverage]
    public class RateLimited : TooManyRequests
    {
        public RateLimited() { }
        public RateLimited(string message) : base(message) { }
        public RateLimited(string message, Exception inner) : base(message, inner) { }
    }
}
