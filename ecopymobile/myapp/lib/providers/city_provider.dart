import 'package:myapp/providers/base_provider.dart';

import '../model/city.dart';

class CityProvider extends BaseProvider<City> {
  CityProvider() : super("City");

  @override
  City fromJson(data) {
    // TODO: implement fromJson
    return City.fromJson(data);
  }
}
