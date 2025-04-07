<?php

namespace App\Http\Controllers\API;

use App\Models\Suggestion;
use Illuminate\Http\Request;
use App\Http\Controllers\Controller;
use App\Http\Resources\SuggestionResource;

class SuggestionController extends Controller
{
    public function store(Request $request)
    {
        $validated = $request->validate([
            'title' => 'required|string|max:255',
            'youtube_url' => 'required|url',
        ]);

        $suggestion = Suggestion::create([
            'user_id' => auth()->id(),
            'title' => $validated['title'],
            'youtube_url' => $validated['youtube_url'],
            'status' => 'pending',
        ]);

        return new SuggestionResource($suggestion);
    }
}
