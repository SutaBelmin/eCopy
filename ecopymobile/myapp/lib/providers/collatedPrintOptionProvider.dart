import 'dart:convert';

import 'package:myapp/model/print_options/collatedResponse.dart';
import 'package:myapp/providers/base_provider.dart';

class CollatedPrintOptionProvider extends BaseProvider<CollatedResponse> {
  CollatedPrintOptionProvider() : super("Collated");

  @override
  CollatedResponse fromJson(data) {
    // TODO: implement fromJson
    return CollatedResponse.fromJson(data);
  }

  Future<List<CollatedResponse>> GetActive() async {
    //var url = "https://10.0.2.2:7284/Collated/GetActive";

    var urlM = const String.fromEnvironment("baseUrl",
        defaultValue: "http://10.0.2.2:5000/");
    var url = "${urlM}Collated/GetActive";

    var uri = Uri.parse(url);

    Map<String, String> headers = createHeaders();

    var response = await http!.get(uri, headers: headers);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return data.map((x) => fromJson(x)).cast<CollatedResponse>().toList();
    } else {
      throw Exception("Exception... handle this gracefully");
    }
  }
}
