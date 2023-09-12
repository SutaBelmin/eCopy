import 'dart:ffi';

import 'package:json_annotation/json_annotation.dart';

part 'pagePerSheetResponse.g.dart';

@JsonSerializable()
class PagePerSheetResponse {
  int? id;
  String? name;
  bool? isActive;

  PagePerSheetResponse() {}

  factory PagePerSheetResponse.fromJson(Map<String, dynamic> json) =>
      _$PagePerSheetResponseFromJson(json);

  /// Connect the generated [_$PagePerSheetResponseToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$PagePerSheetResponseToJson(this);
}
