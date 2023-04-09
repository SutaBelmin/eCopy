import 'dart:ffi';
import 'package:json_annotation/json_annotation.dart';
import 'package:myapp/model/registrationModel/response/countryResponse.dart';

part 'cityResponse.g.dart';

@JsonSerializable()
class CityResponse {
  int? id;
  String? name;
  String? shortName;
  int? postalCode;
  CountryResponse? country;
  int? countryID;
  bool? active;

  CityResponse() {}

  factory CityResponse.fromJson(Map<String, dynamic> json) =>
      _$CityResponseFromJson(json);

  /// Connect the generated [_$CityResponseToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$CityResponseToJson(this);
}
