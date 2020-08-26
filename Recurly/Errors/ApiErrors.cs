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
    public static class Factory
    {
        public static ApiError Create(Recurly.Resources.ErrorMayHaveTransaction err)
        {
            switch (err.Type)
            {
                case Constants.ErrorType.BadRequest:
                    return new BadRequest(err.Message)
                    {
                        Error = err
                    };
                case Constants.ErrorType.ImmutableSubscription:
                    return new ImmutableSubscription(err.Message)
                    {
                        Error = err
                    };
                case Constants.ErrorType.InternalServerError:
                    return new InternalServer(err.Message)
                    {
                        Error = err
                    };
                case Constants.ErrorType.InvalidApiKey:
                    return new InvalidApiKey(err.Message)
                    {
                        Error = err
                    };
                case Constants.ErrorType.InvalidApiVersion:
                    return new InvalidApiVersion(err.Message)
                    {
                        Error = err
                    };
                case Constants.ErrorType.InvalidContentType:
                    return new InvalidContentType(err.Message)
                    {
                        Error = err
                    };
                case Constants.ErrorType.InvalidPermissions:
                    return new InvalidPermissions(err.Message)
                    {
                        Error = err
                    };
                case Constants.ErrorType.InvalidToken:
                    return new InvalidToken(err.Message)
                    {
                        Error = err
                    };
                case Constants.ErrorType.MissingFeature:
                    return new MissingFeature(err.Message)
                    {
                        Error = err
                    };
                case Constants.ErrorType.NotFound:
                    return new NotFound(err.Message)
                    {
                        Error = err
                    };
                case Constants.ErrorType.RateLimited:
                    return new RateLimited(err.Message)
                    {
                        Error = err
                    };
                case Constants.ErrorType.SimultaneousRequest:
                    return new SimultaneousRequest(err.Message)
                    {
                        Error = err
                    };
                case Constants.ErrorType.Transaction:
                    return new Transaction(err.Message)
                    {
                        Error = err
                    };
                case Constants.ErrorType.Unauthorized:
                    return new Unauthorized(err.Message)
                    {
                        Error = err
                    };
                case Constants.ErrorType.UnavailableInApiVersion:
                    return new UnavailableInApiVersion(err.Message)
                    {
                        Error = err
                    };
                case Constants.ErrorType.UnknownApiVersion:
                    return new UnknownApiVersion(err.Message)
                    {
                        Error = err
                    };
                case Constants.ErrorType.Validation:
                    return new Validation(err.Message)
                    {
                        Error = err
                    };
                default:
                    // Explode if we are in strict mode
                    if (Utils.StrictMode)
                    {
                        throw new ArgumentException($"{err.Type} has no valid exception class");
                    }
                    // Fall back to generic API error if we are in production
                    else
                    {
                        return new ApiError(err.Message)
                        {
                            Error = err
                        };
                    }
            }
        }
    }

    [ExcludeFromCodeCoverage]
    public class BadRequest : ApiError
    {
        public BadRequest() { }
        public BadRequest(string message) : base(message) { }
        public BadRequest(string message, Exception inner) : base(message, inner) { }
    }
    [ExcludeFromCodeCoverage]
    public class ImmutableSubscription : ApiError
    {
        public ImmutableSubscription() { }
        public ImmutableSubscription(string message) : base(message) { }
        public ImmutableSubscription(string message, Exception inner) : base(message, inner) { }
    }
    [ExcludeFromCodeCoverage]
    public class InternalServer : ApiError
    {
        public InternalServer() { }
        public InternalServer(string message) : base(message) { }
        public InternalServer(string message, Exception inner) : base(message, inner) { }
    }
    [ExcludeFromCodeCoverage]
    public class InvalidApiKey : ApiError
    {
        public InvalidApiKey() { }
        public InvalidApiKey(string message) : base(message) { }
        public InvalidApiKey(string message, Exception inner) : base(message, inner) { }
    }
    [ExcludeFromCodeCoverage]
    public class InvalidApiVersion : ApiError
    {
        public InvalidApiVersion() { }
        public InvalidApiVersion(string message) : base(message) { }
        public InvalidApiVersion(string message, Exception inner) : base(message, inner) { }
    }
    [ExcludeFromCodeCoverage]
    public class InvalidContentType : ApiError
    {
        public InvalidContentType() { }
        public InvalidContentType(string message) : base(message) { }
        public InvalidContentType(string message, Exception inner) : base(message, inner) { }
    }
    [ExcludeFromCodeCoverage]
    public class InvalidPermissions : ApiError
    {
        public InvalidPermissions() { }
        public InvalidPermissions(string message) : base(message) { }
        public InvalidPermissions(string message, Exception inner) : base(message, inner) { }
    }
    [ExcludeFromCodeCoverage]
    public class InvalidToken : ApiError
    {
        public InvalidToken() { }
        public InvalidToken(string message) : base(message) { }
        public InvalidToken(string message, Exception inner) : base(message, inner) { }
    }
    [ExcludeFromCodeCoverage]
    public class MissingFeature : ApiError
    {
        public MissingFeature() { }
        public MissingFeature(string message) : base(message) { }
        public MissingFeature(string message, Exception inner) : base(message, inner) { }
    }
    [ExcludeFromCodeCoverage]
    public class NotFound : ApiError
    {
        public NotFound() { }
        public NotFound(string message) : base(message) { }
        public NotFound(string message, Exception inner) : base(message, inner) { }
    }
    [ExcludeFromCodeCoverage]
    public class RateLimited : ApiError
    {
        public RateLimited() { }
        public RateLimited(string message) : base(message) { }
        public RateLimited(string message, Exception inner) : base(message, inner) { }
    }
    [ExcludeFromCodeCoverage]
    public class SimultaneousRequest : ApiError
    {
        public SimultaneousRequest() { }
        public SimultaneousRequest(string message) : base(message) { }
        public SimultaneousRequest(string message, Exception inner) : base(message, inner) { }
    }
    [ExcludeFromCodeCoverage]
    public class Transaction : ApiError
    {
        public Transaction() { }
        public Transaction(string message) : base(message) { }
        public Transaction(string message, Exception inner) : base(message, inner) { }
    }
    [ExcludeFromCodeCoverage]
    public class Unauthorized : ApiError
    {
        public Unauthorized() { }
        public Unauthorized(string message) : base(message) { }
        public Unauthorized(string message, Exception inner) : base(message, inner) { }
    }
    [ExcludeFromCodeCoverage]
    public class UnavailableInApiVersion : ApiError
    {
        public UnavailableInApiVersion() { }
        public UnavailableInApiVersion(string message) : base(message) { }
        public UnavailableInApiVersion(string message, Exception inner) : base(message, inner) { }
    }
    [ExcludeFromCodeCoverage]
    public class UnknownApiVersion : ApiError
    {
        public UnknownApiVersion() { }
        public UnknownApiVersion(string message) : base(message) { }
        public UnknownApiVersion(string message, Exception inner) : base(message, inner) { }
    }
    [ExcludeFromCodeCoverage]
    public class Validation : ApiError
    {
        public Validation() { }
        public Validation(string message) : base(message) { }
        public Validation(string message, Exception inner) : base(message, inner) { }
    }
}
