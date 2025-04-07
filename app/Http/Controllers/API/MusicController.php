<?php

namespace App\Http\Controllers\API;

use App\Models\Music;
use Illuminate\Http\Request;
use App\Http\Resources\MusicResource;
use App\Http\Controllers\Controller;

class MusicController extends Controller
{
    public function index()
    {
        return MusicResource::collection(
            Music::orderByDesc('plays')->paginate(5)
        );
    }

    public function show(Music $music)
    {
        return new MusicResource($music);
    }

    public function store(Request $request)
    {
        $validated = $request->validate([
            'title' => 'required|string|max:255',
            'youtube_url' => 'required|url',
        ]);

        $music = Music::create($validated);

        return new MusicResource($music);
    }

    public function update(Request $request, Music $music)
    {
        $validated = $request->validate([
            'title' => 'sometimes|required|string|max:255',
            'youtube_url' => 'sometimes|required|url',
            'plays' => 'sometimes|integer|min:0',
        ]);

        $music->update($validated);

        return new MusicResource($music);
    }

    public function destroy(Music $music)
    {
        $music->delete();

        return response()->json(['message' => 'Music deleted']);
    }
}
