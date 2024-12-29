import { useEffect, useState } from "react";

interface FetchState<T> {
  data: T | null;
  loading: boolean;
  error: string | null;
}

function useFetch<T>(url: string): FetchState<T> {
  const [state, setState] = useState<FetchState<T>>({
    data: null,
    loading: true,
    error: null,
  });

  useEffect(() => {
    const fetchData = async () => {
      try {
        setState((prev) => ({ ...prev, loading: true, error: null }));
        const response = await fetch(url);
        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }
        const result: T = await response.json();
        setState({ data: result, loading: false, error: null });
      } catch (errorObj: any) {
        setState({
          data: null,
          loading: false,
          error: (errorObj as Error).message,
        });
      }
    };

    fetchData();
  }, [url]);

  return state;
}

export default useFetch;
