import 'dart:convert';

import 'package:myapp/model/clmodel.dart';
import 'package:myapp/providers/base_provider.dart';

class ClProvider extends BaseProvider<Clmodel> {
  ClProvider() : super("User");

  @override
  Clmodel fromJson(data) {
    // TODO: implement fromJson
    return Clmodel.fromJson(data);
  }

  Future<Clmodel?> GetByUsrnameOrEmail(String username, String email) async {
    /*var url =
        "https://10.0.2.2:7284/User/GetByUsrnameOrEmail?username=$username&email=$email";*/

    /*var url =
        "http://10.0.2.2:5000/User/GetByUsrnameOrEmail?username=$username&email=$email";*/

    var urlM = const String.fromEnvironment("baseUrl",
        defaultValue: "http://10.0.2.2:5000/");
    var url = "${urlM}User/GetByUsrnameOrEmail?username=$username&email=$email";

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
