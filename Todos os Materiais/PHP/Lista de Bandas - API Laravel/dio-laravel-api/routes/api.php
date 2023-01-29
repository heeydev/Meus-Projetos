<?php

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;

/*
|--------------------------------------------------------------------------
| API Routes
|--------------------------------------------------------------------------
|
| Here is where you can register API routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| is assigned the "api" middleware group. Enjoy building your API!
|
*/

Route::get('hello/{name}', function($name) {
    return "hello " . $name;
});


Route::group(['namespace' => 'App\Http\Controllers'], function(){
    Route::get('bands', 'BandController@getAll');
    //Route::post('hello-post/{name}', 'HelloWorldController@hello');
    Route::get('bands/{id}', 'BandController@getById');
    Route::get('bands/gender/{gender}', 'BandController@getBandsByGender');
    Route::post('bands/store', 'BandController@store');
});

// Route::middleware('auth:sanctum')->get('/user', function (Request $request) {
//     return $request->user();
// });
