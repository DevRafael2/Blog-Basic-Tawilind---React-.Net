import { useState } from "react";
import { Post } from "../interfaces/Post";
import { getPost, getPosts, deletePost } from "../services/postService";
import { useAuth } from "./useAuth";

const usePosts = () => {
  const [posts, setPosts] = useState<Post[]>([]);
  const auth = useAuth();
  
  const fetchPosts = async () => {
    try {
      const authToken: any = auth?.getAuthToken();
      const fetchedPosts: any = await getPosts(authToken);
      setPosts(fetchedPosts);
    } catch (error) {
      console.error("Error fetching posts:", error);
    }
  };

  const fetchPost = async (postId:string) => {
    try {
      const authToken: any = auth?.getAuthToken();
      const fetchedPost: any = await getPost(authToken, postId);
      return fetchedPost;
    } catch (error) {
      console.error("Error fetching posts:", error);
    }
  }

  const fetchDeletePost = async (postId: string) => {
    try {
      const authToken: any = auth?.getAuthToken();
      const response = await deletePost(authToken, postId);
      return response;
    } catch (error) {
      console.error("Error deleting posts:", error);
    }
  };

  return {
    posts,
    fetchPosts,
    fetchPost,
    fetchDeletePost
  };
};

export default usePosts;
