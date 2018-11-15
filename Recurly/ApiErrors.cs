using System;

namespace Recurly {
  public enum ApiErrorTypes {
        bad_request,
        internal_server,
        immutable_subscription,
        invalid_api_key,
        invalid_api_version,
        invalid_content_type,
        invalid_permissions,
        invalid_token,
        not_found,
        simultaneous_request,
        transaction,
        unauthorized,
        unavailable_in_api_version,
        unknown_api_version,
        validation,
        missing_feature,
      }
}
