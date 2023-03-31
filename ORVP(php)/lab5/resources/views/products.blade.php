@extends('layout')
@section('title', 'Products')
@section('content')

<div class="container mt-2">
        <div class="row">
            <div class="col-lg-12 margin-tb">
                <div class="pull-left mb-2">
                    <h2>Add product</h2>
                </div>
            </div>
        </div>
        @if(session('status'))
        <div class="alert alert-success mb-1 mt-1">
            {{ session('status') }}
        </div>
        @endif
        <form action="{{ route('product.store') }}" method="POST" enctype="multipart/form-data">
            @csrf
            <div class="row">
                <div class="col-xs-12 col-sm-12 col-md-12">
                    <div class="form-group">
                        <strong>product Name:</strong>
                        <input type="text" name="name" class="form-control" placeholder="Name">
                        @error('name')
                        <div class="alert alert-danger mt-1 mb-1">{{ $message }}</div>
                        @enderror
                    </div>
                </div>
                <div class="col-xs-12 col-sm-12 col-md-12">
                    <div class="form-group">
                        <strong>Description:</strong>
                        <input type="text" name="description" class="form-control" placeholder="Description">
                        @error('description')
                        <div class="alert alert-danger mt-1 mb-1">{{ $message }}</div>
                        @enderror
                    </div>
                </div>
                <div class="col-xs-12 col-sm-12 col-md-12">
                    <div class="form-group">
                        <strong>Price:</strong>
                        <input type="text" name="price" class="form-control" placeholder="Price">
                        @error('price')
                        <div class="alert alert-danger mt-1 mb-1">{{ $message }}</div>
                        @enderror
                    </div>
                </div>
                <div class="col-xs-12 col-sm-12 col-md-12">
                    <div class="form-group">
                        <strong>Photo Url:</strong>
                        <input type="text" name="photo" class="form-control" placeholder="Photo url">
                        @error('photo')
                        <div class="alert alert-danger mt-1 mb-1">{{ $message }}</div>
                        @enderror
                    </div>
                </div>
                <button type="submit" class="btn btn-primary ml-3">Create</button>
            </div>
        </form>
    </div>

<form action="{{ route('product.cart') }}" method="get">
  @method('GET')
  <button type="submit" class="btn btn-danger">Очистить сессию</button>
</form>

<div class="container products">
 <div class="row">
   @foreach($products as $product)
   <div class="col-xs-18 col-sm-6 col-md-3">
     <div class="thumbnail">
       <img src="{{ $product->photo }}" width="247" height="300">
       <div class="caption">
         <h4>{{ $product->id }}.{{ $product->name }}</h4>
         <p>{{ \Illuminate\Support\Str::limit(strtolower($product->description), 50) }}</p>
         <p><strong>Price: </strong> {{ $product->price }}$</p>
         <p class="btn-holder">
         <a class="btn btn-primary" href="{{ route('product.edit',$product->id) }}">Редактировать</a>
          <form action="{{ route('product.destroy',$product->id) }}" method="Post">
            @csrf
            @method('DELETE')
            <button type="submit" class="btn btn-danger">Удалить</button>
          </form>
          
          <form action="{{ route('product.cart') }}" method="Post">
            <input type="hidden" name="id" value="{{$product->id}}">
            @csrf
            <button type="submit" class="btn btn-warning">В корзину</button>
          </form>
        </p>
       </div>
     </div>
   </div>
   @endforeach
   
 </div>
</div>

@endsection
