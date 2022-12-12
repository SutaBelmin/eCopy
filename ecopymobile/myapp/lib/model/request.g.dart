// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'request.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Request _$RequestFromJson(Map<String, dynamic> json) => Request()
  ..ID = json['ID'] as int?
  ..Status = json['Status'] as String?
  ..Side = json['Side'] as String?
  ..Options = json['Options'] as String?
  ..Orientation = json['Orientation'] as String?
  ..Letter = json['Letter'] as String?
  ..Collate = json['Collate'] as String?;

Map<String, dynamic> _$RequestToJson(Request instance) => <String, dynamic>{
      'ID': instance.ID,
      'Status': instance.Status,
      'Side': instance.Side,
      'Options': instance.Options,
      'Orientation': instance.Orientation,
      'Letter': instance.Letter,
      'Collate': instance.Collate,
    };
