// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'orientationResponse.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

OrientationResponse _$OrientationResponseFromJson(Map<String, dynamic> json) =>
    OrientationResponse()
      ..id = json['id'] as int?
      ..name = json['name'] as String?
      ..isActive = json['isActive'] as bool?;

Map<String, dynamic> _$OrientationResponseToJson(
        OrientationResponse instance) =>
    <String, dynamic>{
      'id': instance.id,
      'name': instance.name,
      'isActive': instance.isActive,
    };
