import 'dart:ffi';

import 'package:json_annotation/json_annotation.dart';

part 'cityAddModel.g.dart';

@JsonSerializable()
class CityAddModel {
  String? name;
  String? shortName;
  int? postalCode;
  int? countryID;
  bool? active;

  CityAddModel() {}

  factory CityAddModel.fromJson(Map<String, dynamic> json) =>
      _$CityAddModelFromJson(json);

  /// Connect the generated [_$CityAddModelToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$CityAddModelToJson(this);
}
