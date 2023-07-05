import 'dart:convert';

import 'package:myapp/model/registrationModel/response/clientResponse.dart';
import 'package:myapp/providers/base_provider.dart';

class UserProvider extends BaseProvider<ClientResponse> {
  UserProvider() : super("Client");

  @override
  ClientResponse fromJson(data) {
    // TODO: implement fromJson
    return ClientResponse.fromJson(data);
  }

  Future<ClientResponse?> getByUsername(String username) async {
    var url =
        "http://10.0.2.2:5000/Client/GetByUsername?" + "username=" + username;
    var uri = Uri.parse(url);

    Map<String, String> headers = createHeaders();

    var response = await http!.get(uri, headers: headers);

    if (isValidResponseCode(response)) {
      if (response.body == "") {
        return null;
      }
      var data = jsonDecode(response.body);
      return fromJson(data);
    } else {
      throw Exception("Exception... handle this gracefully");
    }
  }
}
