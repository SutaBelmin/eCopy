import 'dart:ffi';
import 'package:json_annotation/json_annotation.dart';

part 'countryResponse.g.dart';

@JsonSerializable()
class CountryResponse {
  int? id;
  String? name;
  String? shortName;
  String? phoneNumberCode;
  String? phoneNumberRegex;
  bool? active;

  CountryResponse() {}

  factory CountryResponse.fromJson(Map<String, dynamic> json) =>
      _$CountryResponseFromJson(json);

  /// Connect the generated [_$CountryResponseToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$CountryResponseToJson(this);
}
