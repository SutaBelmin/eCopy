// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'updateRequest.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

UpdateRequest _$UpdateRequestFromJson(Map<String, dynamic> json) =>
    UpdateRequest()
      ..status = json['status'] as int?
      ..options = json['options'] as int?
      ..side = json['side'] as int?
      ..orientation = json['orientation'] as int?
      ..letter = json['letter'] as int?
      ..pages = json['pages'] as int?
      ..collate = json['collate'] as int?;

Map<String, dynamic> _$UpdateRequestToJson(UpdateRequest instance) =>
    <String, dynamic>{
      'status': instance.status,
      'options': instance.options,
      'side': instance.side,
      'orientation': instance.orientation,
      'letter': instance.letter,
      'pages': instance.pages,
      'collate': instance.collate,
    };
