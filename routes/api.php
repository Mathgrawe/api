<?php

use Illuminate\Support\Facades\Route;
use App\Http\Controllers\Auth\AuthController;
use App\Http\Controllers\API\MusicController;
use App\Http\Controllers\API\SuggestionController;
use App\Http\Controllers\API\AdminSuggestionController;

Route::prefix('v1')->group(function () {

    Route::post('/register', [AuthController::class, 'register']);
    Route::post('/login', [AuthController::class, 'login']);

    Route::middleware('auth:sanctum')->group(function () {

        Route::post('/logout', [AuthController::class, 'logout']);

        Route::post('/suggestions', [SuggestionController::class, 'store']);

        Route::middleware('can:admin')->prefix('admin')->group(function () {
            Route::get('/suggestions', [AdminSuggestionController::class, 'index']);
            Route::put('/suggestions/{id}/approve', [AdminSuggestionController::class, 'approve']);
            Route::put('/suggestions/{id}/reject', [AdminSuggestionController::class, 'reject']);
            Route::delete('/suggestions/{id}', [AdminSuggestionController::class, 'destroy']);
        });
    });

    Route::get('/musics', [MusicController::class, 'index']);
    Route::get('/musics/{music:id}', [MusicController::class, 'show']);
});
