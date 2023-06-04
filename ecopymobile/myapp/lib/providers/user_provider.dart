import 'package:myapp/model/registrationModel/response/clientResponse.dart';
import 'package:myapp/providers/base_provider.dart';

class UserProvider extends BaseProvider<ClientResponse> {
  UserProvider() : super("Client");

  @override
  ClientResponse fromJson(data) {
    // TODO: implement fromJson
    //return ClientResponse();
    return ClientResponse.fromJson(data);
  }
}
