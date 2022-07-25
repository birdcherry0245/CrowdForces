function dijkstra(g: int[][][], n: int, s: int, t: int) -> int {
    let dist: int[] = [];
    for (let v = 0; v < n; v += 1) {
        dist[v] = 10000000000 * n;
    }

    let S: {int: bool} = {};
    dist[s] = 0;
    S[0 * n + s] = true;
    while(S.length() > 0) {
        let key = S.keys()[0];
        let v = key % n;
        S.remove(key);

        for (let i = 0; i < g[v].length(); i += 1) {
            let u = g[v][i][0];
            let w = g[v][i][1];
            if (dist[v] + w < dist[u]) {
                S.remove(dist[u] * n + u);
                dist[u] = dist[v] + w;
                S[dist[u] * n + u] = true;
            }
        }
    }
    
    return dist[t];
}
