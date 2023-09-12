import 'dart:convert';

import 'package:myapp/model/print_options/orientationResponse.dart';
import 'package:myapp/providers/base_provider.dart';

class OrientationProvider extends BaseProvider<OrientationResponse> {
  OrientationProvider() : super("Orientation");

  @override
  OrientationResponse fromJson(data) {
    // TODO: implement fromJson
    return OrientationResponse.fromJson(data);
  }

  Future<List<OrientationResponse>> GetActive() async {
    //var url = "https://10.0.2.2:7284/Orientation/GetActive";

    var urlM = const String.fromEnvironment("baseUrl",
        defaultValue: "http://10.0.2.2:5000/");
    var url = "${urlM}Orientation/GetActive";

    var uri = Uri.parse(url);

    Map<String, String> headers = createHeaders();

    var response = await http!.get(uri, headers: headers);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return data.map((x) => fromJson(x)).cast<OrientationResponse>().toList();
    } else {
      throw Exception("Exception... handle this gracefully");
    }
  }
}
