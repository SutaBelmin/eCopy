import 'dart:convert';

import 'package:myapp/model/clientRequestUpdate.dart';
import 'package:myapp/model/passRequest.dart';
import 'package:myapp/model/registrationModel/response/clientResponse.dart';
import 'package:myapp/providers/base_provider.dart';

class UserProvider extends BaseProvider<ClientResponse> {
  UserProvider() : super("Client");

  @override
  ClientResponse fromJson(data) {
    // TODO: implement fromJson
    return ClientResponse.fromJson(data);
  }

  Future<ClientResponse?> getByUsername(String username, String email) async {
    /*var url =
        "https://10.0.2.2:7284/Client/GetByUsername?username=$username&email=$email";*/

    var url =
        "http://10.0.2.2:5000/Client/GetByUsername?username=$username&email=$email";

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

  Future<ClientResponse?> getClientAccount() async {
    //var url = "https://10.0.2.2:7284/Client/GetClientAccount";

    var url = "http://10.0.2.2:5000/Client/GetClientAccount";

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

  Future<bool?> ChangePass(PassRequest update) async {
    //var url = "https://10.0.2.2:7284/Client/ChangePass";

    var url = "http://10.0.2.2:5000/Client/ChangePass";

    var uri = Uri.parse(url);

    Map<String, String> headers = createHeaders();
    var response =
        await http!.put(uri, body: jsonEncode(update), headers: headers);

    if (response.body == "false") {
      return false;
    }

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return true;
    } else {
      return false;
    }
  }

  Future<ClientResponse?> updateClient(ClientRequestUpdate update) async {
    //var url = "https://10.0.2.2:7284/Client/MyUpdateClient";

    var url = "http://10.0.2.2:5000/Client/MyUpdateClient";

    //var url = "http://10.0.2.2:5000/PrintRequest/Update/${id}";
    var uri = Uri.parse(url);

    Map<String, String> headers = createHeaders();

    var response =
        await http!.put(uri, body: jsonEncode(update), headers: headers);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return fromJson(data);
    } else {
      return null;
    }
  }
}
