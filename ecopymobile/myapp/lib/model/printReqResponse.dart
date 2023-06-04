import 'dart:ffi';

import 'package:json_annotation/json_annotation.dart';

//part 'printReqResponse.g.dart';

@JsonSerializable()
class PrintReqResponse {
  String? id;
  int? status;
  //String? filePath;
  int? options;
  int? side;
  int? orientation;
  int? letter;
  int? pagePerSheet;
  int? collate;
  /*
  public int ClientId { get; set; }

        public ClientResponse Client { get; set; }
        public int CopierId { get; set; }

        public CopierResponse Copier { get; set; }
        public DateTime RequestDate { get; set; }
   */

  PrintReqResponse() {}
/*
  factory PrintReqResponse.fromJson(Map<String, dynamic> json) =>
      _$PrintReqResponseFromJson(json);

  /// Connect the generated [_$PrintRequestToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$PrintReqResponseToJson(this);*/
}
