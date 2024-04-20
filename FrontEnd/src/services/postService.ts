import Swal from "sweetalert2";
import { apiAxios } from "../api/api";
import { Post } from "../interfaces/Post";

const getPosts = async (token: string): Promise<void> => {
  const response = await apiAxios.get(`/Api/Post`, {
    headers: { Authorization: `Bearer ${token}` },
  });

  return response.data.data;
};

const getPost = async (token: string, postId:string): Promise<Post> => {
  const response = await apiAxios.get(`/Api/Post/${ postId }`, {
    headers: { Authorization: `Bearer ${token}` },
  });
  return response.data.data;
}

const createPost = async (token: string, title: string, description: string, userId:number): Promise<Post> => {
  const response = await apiAxios.post(`/Api/Post`, {
    title,
    descriptionPost: description,
    userId
  }, {headers: {
    Authorization: `Bearer ${ token }`
  }});

  if (!response.data.isComplete) {
    Swal.fire({
      title: response.data.message,
      icon: "error",
      showConfirmButton: true,
      showCancelButton: false
    });
  }
  return response.data.data;
};

const editPost = async (token: string, postId: string, title: string, description: string, userId:number): Promise<Post> => {
  const response = await apiAxios.put(`/Api/Post/${ postId }`, {
    title,
    descriptionPost: description,
    userId
  }, { headers: { Authorization: `Bearer ${ token }` } });
  if (!response.data.isComplete) {
    Swal.fire({
      title: response.data.message,
      icon: "error",
      showConfirmButton: true,
      showCancelButton: false
    });
  }
  return response.data;
};

const deletePost = async (token:string, postId: string): Promise<void> => {
  const response = await apiAxios.delete(`/Api/Post/${ postId }`, {headers: { Authorization: `Bearer ${ token }` }})
  if (!response.data.isComplete) {
    Swal.fire({
      title: response.data.message,
      icon: "error",
      showConfirmButton: true,
      showCancelButton: false
    });
  }
  else 
  {
    Swal.fire({
      title: response.data.message,
      icon: "success",
      showConfirmButton: true,
      showCancelButton: false
    });
  }
  return response.data;
};

export { getPosts, getPost, createPost, editPost, deletePost };
