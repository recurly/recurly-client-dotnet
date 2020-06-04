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
                case "bad_request":
                    return new BadRequest(err.Message)
                    {
                        Error = err
                    };
                case "internal_server_error":
                    return new InternalServer(err.Message)
                    {
                        Error = err
                    };
                case "immutable_subscription":
                    return new ImmutableSubscription(err.Message)
                    {
                        Error = err
                    };
                case "invalid_api_key":
                    return new InvalidApiKey(err.Message)
                    {
                        Error = err
                    };
                case "invalid_api_version":
                    return new InvalidApiVersion(err.Message)
                    {
                        Error = err
                    };
                case "invalid_content_type":
                    return new InvalidContentType(err.Message)
                    {
                        Error = err
                    };
                case "invalid_permissions":
                    return new InvalidPermissions(err.Message)
                    {
                        Error = err
                    };
                case "invalid_token":
                    return new InvalidToken(err.Message)
                    {
                        Error = err
                    };
                case "not_found":
                    return new NotFound(err.Message)
                    {
                        Error = err
                    };
                case "simultaneous_request":
                    return new SimultaneousRequest(err.Message)
                    {
                        Error = err
                    };
                case "transaction":
                    return new Transaction(err.Message)
                    {
                        Error = err
                    };
                case "unauthorized":
                    return new Unauthorized(err.Message)
                    {
                        Error = err
                    };
                case "unavailable_in_api_version":
                    return new UnavailableInApiVersion(err.Message)
                    {
                        Error = err
                    };
                case "unknown_api_version":
                    return new UnknownApiVersion(err.Message)
                    {
                        Error = err
                    };
                case "validation":
                    return new Validation(err.Message)
                    {
                        Error = err
                    };
                case "missing_feature":
                    return new MissingFeature(err.Message)
                    {
                        Error = err
                    };
                case "rate_limited":
                    return new RateLimited(err.Message)
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
    public class InternalServer : ApiError
    {
        public InternalServer() { }
        public InternalServer(string message) : base(message) { }
        public InternalServer(string message, Exception inner) : base(message, inner) { }
    }
    public class ImmutableSubscription : ApiError
    {
        public ImmutableSubscription() { }
        public ImmutableSubscription(string message) : base(message) { }
        public ImmutableSubscription(string message, Exception inner) : base(message, inner) { }
    }
    public class InvalidApiKey : ApiError
    {
        public InvalidApiKey() { }
        public InvalidApiKey(string message) : base(message) { }
        public InvalidApiKey(string message, Exception inner) : base(message, inner) { }
    }
    public class InvalidApiVersion : ApiError
    {
        public InvalidApiVersion() { }
        public InvalidApiVersion(string message) : base(message) { }
        public InvalidApiVersion(string message, Exception inner) : base(message, inner) { }
    }
    public class InvalidContentType : ApiError
    {
        public InvalidContentType() { }
        public InvalidContentType(string message) : base(message) { }
        public InvalidContentType(string message, Exception inner) : base(message, inner) { }
    }
    public class InvalidPermissions : ApiError
    {
        public InvalidPermissions() { }
        public InvalidPermissions(string message) : base(message) { }
        public InvalidPermissions(string message, Exception inner) : base(message, inner) { }
    }
    public class InvalidToken : ApiError
    {
        public InvalidToken() { }
        public InvalidToken(string message) : base(message) { }
        public InvalidToken(string message, Exception inner) : base(message, inner) { }
    }
    public class NotFound : ApiError
    {
        public NotFound() { }
        public NotFound(string message) : base(message) { }
        public NotFound(string message, Exception inner) : base(message, inner) { }
    }
    public class SimultaneousRequest : ApiError
    {
        public SimultaneousRequest() { }
        public SimultaneousRequest(string message) : base(message) { }
        public SimultaneousRequest(string message, Exception inner) : base(message, inner) { }
    }
    public class Transaction : ApiError
    {
        public Transaction() { }
        public Transaction(string message) : base(message) { }
        public Transaction(string message, Exception inner) : base(message, inner) { }
    }
    public class Unauthorized : ApiError
    {
        public Unauthorized() { }
        public Unauthorized(string message) : base(message) { }
        public Unauthorized(string message, Exception inner) : base(message, inner) { }
    }
    public class UnavailableInApiVersion : ApiError
    {
        public UnavailableInApiVersion() { }
        public UnavailableInApiVersion(string message) : base(message) { }
        public UnavailableInApiVersion(string message, Exception inner) : base(message, inner) { }
    }
    public class UnknownApiVersion : ApiError
    {
        public UnknownApiVersion() { }
        public UnknownApiVersion(string message) : base(message) { }
        public UnknownApiVersion(string message, Exception inner) : base(message, inner) { }
    }
    public class Validation : ApiError
    {
        public Validation() { }
        public Validation(string message) : base(message) { }
        public Validation(string message, Exception inner) : base(message, inner) { }
    }
    public class MissingFeature : ApiError
    {
        public MissingFeature() { }
        public MissingFeature(string message) : base(message) { }
        public MissingFeature(string message, Exception inner) : base(message, inner) { }
    }
    public class RateLimited : ApiError
    {
        public RateLimited() { }
        public RateLimited(string message) : base(message) { }
        public RateLimited(string message, Exception inner) : base(message, inner) { }
    }
}
