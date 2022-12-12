import 'dart:ffi';

import 'package:json_annotation/json_annotation.dart';

part 'zahtjev.g.dart';

@JsonSerializable()
class Zahtjev {
  int? Id;
  int? status;
  int? side;
  int? options;
  int? orientation;
  int? letter;
  int? collate;

  Zahtjev() {}

  factory Zahtjev.fromJson(Map<String, dynamic> json) =>
      _$ZahtjevFromJson(json);

  /// Connect the generated [_$ZahtjevToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$ZahtjevToJson(this);
}
