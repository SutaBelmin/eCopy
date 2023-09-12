import 'dart:convert';

import 'package:myapp/model/print_options/sideResponse.dart';
import 'package:myapp/providers/base_provider.dart';

class SidePrintOptionProvider extends BaseProvider<SideResponse> {
  SidePrintOptionProvider() : super("Side");

  @override
  SideResponse fromJson(data) {
    // TODO: implement fromJson
    return SideResponse.fromJson(data);
  }

  Future<List<SideResponse>> GetActive() async {
    //var url = "https://10.0.2.2:7284/Side/GetActive";

    var urlM = const String.fromEnvironment("baseUrl",
        defaultValue: "http://10.0.2.2:5000/");
    var url = "${urlM}Side/GetActive";

    var uri = Uri.parse(url);

    Map<String, String> headers = createHeaders();

    var response = await http!.get(uri, headers: headers);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return data.map((x) => fromJson(x)).cast<SideResponse>().toList();
    } else {
      throw Exception("Exception... handle this gracefully");
    }
  }
}
