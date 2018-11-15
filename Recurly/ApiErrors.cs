using System;

namespace Recurly {
  public enum ApiErrorTypes {
        BadRequest,
        InternalServer,
        ImmutableSubscription,
        InvalidApiKey,
        InvalidApiVersion,
        InvalidContentType,
        InvalidPermissions,
        InvalidToken,
        NotFound,
        SimultaneousRequest,
        Transaction,
        Unauthorized,
        UnavailableInApiVersion,
        UnknownApiVersion,
        Validation,
        MissingFeature,
      }
}
