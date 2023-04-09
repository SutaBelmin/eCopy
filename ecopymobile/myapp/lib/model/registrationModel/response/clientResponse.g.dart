// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'clientResponse.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

ClientResponse _$ClientResponseFromJson(Map<String, dynamic> json) =>
    ClientResponse()
      ..id = json['id'] as int?
      ..applicationUser = json['applicationUser'] == null
          ? null
          : ApplicationUserResponse.fromJson(
              json['applicationUser'] as Map<String, dynamic>)
      ..person = json['person'] == null
          ? null
          : PersonResponse.fromJson(json['person'] as Map<String, dynamic>)
      ..personId = json['personId'] as int?
      ..applicationUserId = json['applicationUserId'] as int?;

Map<String, dynamic> _$ClientResponseToJson(ClientResponse instance) =>
    <String, dynamic>{
      'id': instance.id,
      'applicationUser': instance.applicationUser,
      'person': instance.person,
      'personId': instance.personId,
      'applicationUserId': instance.applicationUserId,
    };
