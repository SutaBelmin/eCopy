import 'dart:ffi';

import 'package:json_annotation/json_annotation.dart';

part 'authentication_response.g.dart';

@JsonSerializable()
class AuthenticationResponse {
  AuthenticationResponse(this.Token);
  String Token;

  factory AuthenticationResponse.fromJson(Map<String, dynamic> json) =>
      _$AuthenticationResponseFromJson(json);

  /// Connect the generated [_$RequestToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$AuthenticationResponseToJson(this);
}
