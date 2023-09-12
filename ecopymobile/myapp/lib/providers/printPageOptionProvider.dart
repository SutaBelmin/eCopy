import 'dart:convert';

import 'package:myapp/model/print_options/printPageOptionResponse.dart';
import 'package:myapp/providers/base_provider.dart';

class PrintPageOptionProvider extends BaseProvider<PrintPageOptionResponse> {
  PrintPageOptionProvider() : super("PrintPageOpt");

  @override
  PrintPageOptionResponse fromJson(data) {
    // TODO: implement fromJson
    return PrintPageOptionResponse.fromJson(data);
  }

  Future<List<PrintPageOptionResponse>> GetActive() async {
    //var url = "https://10.0.2.2:7284/PrintPageOpt/GetActive";

    var urlM = const String.fromEnvironment("baseUrl",
        defaultValue: "http://10.0.2.2:5000/");
    var url = "${urlM}PrintPageOpt/GetActive";

    var uri = Uri.parse(url);

    Map<String, String> headers = createHeaders();

    var response = await http!.get(uri, headers: headers);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return data
          .map((x) => fromJson(x))
          .cast<PrintPageOptionResponse>()
          .toList();
    } else {
      throw Exception("Exception... handle this gracefully");
    }
  }
}
