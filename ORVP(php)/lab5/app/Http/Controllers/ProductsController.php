<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\Product;
use DB;

class ProductsController extends Controller
{
    public function index() {
       $products = Product::all();
       return view('products', compact('products'));
    }

    public function create() { return view('product.create'); }

    public function store(Request $request)
    {
        $request->validate([
            'photo' => 'required',
            'name' => 'required',
            'description' => 'required',
            'price' => 'required',
        ]);
        Product::create($request->post());
        return redirect()->route('product.index')->with('success','Product has been created successfully.');
    }

    public function edit(Product $product) { return view('update',compact('product')); }

    public function update(Request $request, Product $product)
    {
        $request->validate([
            'photo' => 'required',
            'name' => 'required',
            'description' => 'required',
            'price' => 'required',
        ]);
        $product->fill($request->post())->save();
        return redirect()->route('product.index')->with('success','Prodct has been updated successfully');
    }

    public function destroy(Product $product)
    {
        $product->delete();
        return redirect()->route('product.index')->with('success','Product has been deleted successfully');
    }

    public function cart(Product $product)
    {
        $sesStr = session('cart');
        $sesStr[] = $_POST["id"];
        session(['cart' => $sesStr]);
        $products = [];
        foreach($sesStr as $id) {
            $products[] = DB::table('products')->where('id', '=', $id)->first();;
        }
        return view('cart',compact('products'));
    }

    public function clearSession()
    {
        session()->flush();
        return redirect()->route('product.index');
    }
}
