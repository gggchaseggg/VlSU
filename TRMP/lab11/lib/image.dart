import 'package:flutter/material.dart';
import 'dart:async';

class DogImage extends StatelessWidget {
  const DogImage({super.key});

  @override
  Widget build(BuildContext context) {
    Text title = const Text(
      "Пора бы уже ложиться спать",
      textDirection: TextDirection.ltr,
    );
    Image image = Image.asset('assets/dog.jpg');

    return Center(
      child: Column(
        children: [title, image],
        mainAxisSize: MainAxisSize.min,
      ),
    );
  }
}

class RandomImageWidget extends StatefulWidget {
  @override
  State<StatefulWidget> createState() {
    return RandomImageState();
  }
}

class RandomImageState extends State<RandomImageWidget> {
  String url = "https://source.unsplash.com/random/800x600";

  void changeURL() {
    setState(() {
      url =
      "https://source.unsplash.com/random/800x600?q=${DateTime.now().millisecondsSinceEpoch}";
    });
  }

  @override
  void initState() {
    Timer.periodic(const Duration(seconds: 10), (timer) {
      changeURL();
    });
    super.initState();
  }

  // A random image from Unsplash
  @override
  Widget build(BuildContext context) {
    return Center(
        child: TextButton(
      child: Image.network(url),
      onPressed: changeURL,
    ));
  }
}
