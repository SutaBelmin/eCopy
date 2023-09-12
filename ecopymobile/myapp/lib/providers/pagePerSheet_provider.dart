import 'dart:convert';

import 'package:myapp/model/print_options/pagePerSheetResponse.dart';
import 'package:myapp/providers/base_provider.dart';

class PagePerSheetProvider extends BaseProvider<PagePerSheetResponse> {
  PagePerSheetProvider() : super("PagePerSheet");

  @override
  PagePerSheetResponse fromJson(data) {
    // TODO: implement fromJson
    return PagePerSheetResponse.fromJson(data);
  }

  Future<List<PagePerSheetResponse>> GetActive() async {
    //var url = "https://10.0.2.2:7284/PagePerSheet/GetActive";

    var urlM = const String.fromEnvironment("baseUrl",
        defaultValue: "http://10.0.2.2:5000/");
    var url = "${urlM}PagePerSheet/GetActive";

    var uri = Uri.parse(url);

    Map<String, String> headers = createHeaders();

    var response = await http!.get(uri, headers: headers);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return data.map((x) => fromJson(x)).cast<PagePerSheetResponse>().toList();
    } else {
      throw Exception("Exception... handle this gracefully");
    }
  }
}
