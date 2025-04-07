<?php

namespace App\Http\Controllers\API;

use App\Models\Suggestion;
use Illuminate\Http\Request;
use App\Http\Controllers\Controller;
use App\Http\Resources\SuggestionResource;

class AdminSuggestionController extends Controller
{
    public function index()
    {
        // Retorna todas as sugestões pendentes
        return SuggestionResource::collection(
            Suggestion::where('status', 'pending')->latest()->paginate(10)
        );
    }

    public function approve($id)
    {
        $suggestion = Suggestion::findOrFail($id);
        $suggestion->status = 'approved';
        $suggestion->save();

        return new SuggestionResource($suggestion);
    }

    public function reject($id)
    {
        $suggestion = Suggestion::findOrFail($id);
        $suggestion->status = 'rejected';
        $suggestion->save();

        return new SuggestionResource($suggestion);
    }

    public function destroy($id)
    {
        $suggestion = Suggestion::findOrFail($id);
        $suggestion->delete();

        return response()->json(['message' => 'Suggestion deleted']);
    }
}
