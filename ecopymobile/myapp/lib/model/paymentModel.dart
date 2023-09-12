import 'dart:ffi';

import 'package:json_annotation/json_annotation.dart';

part 'paymentModel.g.dart';

@JsonSerializable()
class PaymentModel {
  String? stripePaymentId;

  PaymentModel() {}

  factory PaymentModel.fromJson(Map<String, dynamic> json) =>
      _$PaymentModelFromJson(json);

  /// Connect the generated [_$PPaymentModelToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$PaymentModelToJson(this);
}
