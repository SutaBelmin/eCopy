// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'clientRequest.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

ClientRequest _$ClientRequestFromJson(Map<String, dynamic> json) =>
    ClientRequest()
      ..active = json['active'] as bool?
      ..person = json['person'] == null
          ? null
          : PersonRequest.fromJson(json['person'] as Map<String, dynamic>)
      ..user = json['user'] == null
          ? null
          : ApplicationUserRequest.fromJson(
              json['user'] as Map<String, dynamic>);

Map<String, dynamic> _$ClientRequestToJson(ClientRequest instance) =>
    <String, dynamic>{
      'active': instance.active,
      'person': instance.person,
      'user': instance.user,
    };
