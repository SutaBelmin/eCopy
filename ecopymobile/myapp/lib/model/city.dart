import 'dart:ffi';

import 'package:json_annotation/json_annotation.dart';

part 'city.g.dart';

@JsonSerializable()
class City {
  int? id;
  String? name;
  String? shortName;
  int? postalCode;
/*CountryResponse Country
int? CountryID;*/
  bool? active;

  City() {}

  factory City.fromJson(Map<String, dynamic> json) => _$CityFromJson(json);

  /// Connect the generated [_$CityToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$CityToJson(this);
}
