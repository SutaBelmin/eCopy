import 'package:myapp/providers/base_provider.dart';

import '../model/user.dart';

class UserProvider extends BaseProvider<User> {
  UserProvider() : super("Client");

  @override
  User fromJson(data) {
    // TODO: implement fromJson
    return User();
  }
}
