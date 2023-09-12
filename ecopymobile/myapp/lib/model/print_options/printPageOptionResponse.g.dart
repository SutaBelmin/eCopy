// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'printPageOptionResponse.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

PrintPageOptionResponse _$PrintPageOptionResponseFromJson(
        Map<String, dynamic> json) =>
    PrintPageOptionResponse()
      ..id = json['id'] as int?
      ..name = json['name'] as String?
      ..isActive = json['isActive'] as bool?;

Map<String, dynamic> _$PrintPageOptionResponseToJson(
        PrintPageOptionResponse instance) =>
    <String, dynamic>{
      'id': instance.id,
      'name': instance.name,
      'isActive': instance.isActive,
    };
