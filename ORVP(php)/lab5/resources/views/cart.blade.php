@extends('layout')

<div class="container products">
 <div class="row">
    @foreach($products as $product)
      <div class="col-xs-9 col-sm-6 col-md-3 border border-warning rounded mr-3 mt-3">
        <div class="thumbnail">
          <img src="{{ $product->photo }}" width="100" height="120">
          <div class="caption">
            <h4>{{ $product->id }}.{{ $product->name }}</h4>
            <p>{{ \Illuminate\Support\Str::limit(strtolower($product->description), 50) }}</p>
            <p><strong>Price: </strong> {{ $product->price }}$</p>
          </div>
        </div>
      </div>
    @endforeach
  </div>
</div>



