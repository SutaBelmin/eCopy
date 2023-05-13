import 'package:myapp/model/registrationModel/response/clientResponse.dart';
import 'package:myapp/providers/base_provider.dart';
import 'package:myapp/model/registrationModel/clientRequest.dart';

import '../model/user.dart';

class UserProvider extends BaseProvider<ClientResponse> {
  //umjesto User treba biti ClientResponse
  UserProvider() : super("Client");

  @override
  ClientResponse fromJson(data) {
    // TODO: implement fromJson
    //return ClientResponse();
    return ClientResponse.fromJson(data);
  }
}


/*
class UserProvider extends BaseProvider<User> {
  //umjesto User treba biti ClientResponse
  UserProvider() : super("Client");

  @override
  User fromJson(data) {
    // TODO: implement fromJson
    return User();
  }
}*/
