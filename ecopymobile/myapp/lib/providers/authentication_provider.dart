import 'package:myapp/providers/base_provider.dart';

import '../model/authentication_response.dart';

class AuthenticationProvider extends BaseProvider<AuthenticationResponse> {
  AuthenticationProvider() : super("Authentication/login");

  @override
  AuthenticationResponse fromJson(data) {
    // TODO: implement fromJson
    return AuthenticationResponse(data["token"]);
  }
}
