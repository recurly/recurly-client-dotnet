/**
 * This file is automatically created by Recurly's OpenAPI generation process
 * and thus any edits you make by hand will be lost. If you wish to make a
 * change to this file, please create a Github issue explaining the changes you
 * need and we will usher them to the appropriate places.
 */
using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Recurly {
  [JsonConverter(typeof(StringEnumConverter))]
  public enum ApiErrorType {
        [EnumMember(Value = "bad_request")] BadRequest,
        [EnumMember(Value = "internal_server_error")] InternalServer,
        [EnumMember(Value = "immutable_subscription")] ImmutableSubscription,
        [EnumMember(Value = "invalid_api_key")] InvalidApiKey,
        [EnumMember(Value = "invalid_api_version")] InvalidApiVersion,
        [EnumMember(Value = "invalid_content_type")] InvalidContentType,
        [EnumMember(Value = "invalid_permissions")] InvalidPermissions,
        [EnumMember(Value = "invalid_token")] InvalidToken,
        [EnumMember(Value = "not_found")] NotFound,
        [EnumMember(Value = "simultaneous_request")] SimultaneousRequest,
        [EnumMember(Value = "transaction")] Transaction,
        [EnumMember(Value = "unauthorized")] Unauthorized,
        [EnumMember(Value = "unavailable_in_api_version")] UnavailableInApiVersion,
        [EnumMember(Value = "unknown_api_version")] UnknownApiVersion,
        [EnumMember(Value = "validation")] Validation,
        [EnumMember(Value = "missing_feature")] MissingFeature,
      }
}
