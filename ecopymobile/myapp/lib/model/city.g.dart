// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'city.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

City _$CityFromJson(Map<String, dynamic> json) => City()
  ..id = json['id'] as int?
  ..name = json['name'] as String?
  ..shortName = json['shortName'] as String?
  ..postalCode = json['postalCode'] as int?
  ..active = json['active'] as bool?;

Map<String, dynamic> _$CityToJson(City instance) => <String, dynamic>{
      'id': instance.id,
      'name': instance.name,
      'shortName': instance.shortName,
      'postalCode': instance.postalCode,
      'active': instance.active,
    };
