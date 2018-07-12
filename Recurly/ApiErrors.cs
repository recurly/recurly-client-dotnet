using System;

namespace Recurly {
  
  public class BadRequestError : ApiError {
    public BadRequestError(string message) : base(message) {}

    public BadRequestError(string message, Exception inner) : base(message, inner) {}
  }
  
  public class InternalServerError : ApiError {
    public InternalServerError(string message) : base(message) {}

    public InternalServerError(string message, Exception inner) : base(message, inner) {}
  }
  
  public class ImmutableSubscriptionError : ApiError {
    public ImmutableSubscriptionError(string message) : base(message) {}

    public ImmutableSubscriptionError(string message, Exception inner) : base(message, inner) {}
  }
  
  public class InvalidApiKeyError : ApiError {
    public InvalidApiKeyError(string message) : base(message) {}

    public InvalidApiKeyError(string message, Exception inner) : base(message, inner) {}
  }
  
  public class InvalidApiVersionError : ApiError {
    public InvalidApiVersionError(string message) : base(message) {}

    public InvalidApiVersionError(string message, Exception inner) : base(message, inner) {}
  }
  
  public class InvalidContentTypeError : ApiError {
    public InvalidContentTypeError(string message) : base(message) {}

    public InvalidContentTypeError(string message, Exception inner) : base(message, inner) {}
  }
  
  public class InvalidPermissionsError : ApiError {
    public InvalidPermissionsError(string message) : base(message) {}

    public InvalidPermissionsError(string message, Exception inner) : base(message, inner) {}
  }
  
  public class InvalidTokenError : ApiError {
    public InvalidTokenError(string message) : base(message) {}

    public InvalidTokenError(string message, Exception inner) : base(message, inner) {}
  }
  
  public class NotFoundError : ApiError {
    public NotFoundError(string message) : base(message) {}

    public NotFoundError(string message, Exception inner) : base(message, inner) {}
  }
  
  public class SimultaneousRequestError : ApiError {
    public SimultaneousRequestError(string message) : base(message) {}

    public SimultaneousRequestError(string message, Exception inner) : base(message, inner) {}
  }
  
  public class TransactionError : ApiError {
    public TransactionError(string message) : base(message) {}

    public TransactionError(string message, Exception inner) : base(message, inner) {}
  }
  
  public class UnauthorizedError : ApiError {
    public UnauthorizedError(string message) : base(message) {}

    public UnauthorizedError(string message, Exception inner) : base(message, inner) {}
  }
  
  public class UnavailableInApiVersionError : ApiError {
    public UnavailableInApiVersionError(string message) : base(message) {}

    public UnavailableInApiVersionError(string message, Exception inner) : base(message, inner) {}
  }
  
  public class UnknownApiVersionError : ApiError {
    public UnknownApiVersionError(string message) : base(message) {}

    public UnknownApiVersionError(string message, Exception inner) : base(message, inner) {}
  }
  
  public class ValidationError : ApiError {
    public ValidationError(string message) : base(message) {}

    public ValidationError(string message, Exception inner) : base(message, inner) {}
  }
  
  public class MissingFeatureError : ApiError {
    public MissingFeatureError(string message) : base(message) {}

    public MissingFeatureError(string message, Exception inner) : base(message, inner) {}
  }
  
}
