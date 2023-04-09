// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'printRequest.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

PrintRequest _$PrintRequestFromJson(Map<String, dynamic> json) => PrintRequest()
  ..status = json['status'] as int?
  ..side = json['side'] as int?
  ..options = json['options'] as int?
  ..orientation = json['orientation'] as int?
  ..letter = json['letter'] as int?
  ..collate = json['collate'] as int?
  ..pagePerSheet = json['pagePerSheet'] as int?;

Map<String, dynamic> _$PrintRequestToJson(PrintRequest instance) =>
    <String, dynamic>{
      'status': instance.status,
      'side': instance.side,
      'options': instance.options,
      'orientation': instance.orientation,
      'letter': instance.letter,
      'collate': instance.collate,
      'pagePerSheet': instance.pagePerSheet,
    };
